using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using MS.Internal;


namespace FullDemo
{
	public class IStreamWrapper : IStream
	{
		private Stream		m_stream;
		private Int64		m_pos;
		private Object		m_sync;

		public enum STGTY : int
		{
			STGTY_STORAGE	= 1,
			STGTY_STREAM	= 2,
			STGTY_LOCKBYTES	= 3,
			STGTY_PROPERTY	= 4
		}

		public enum STGM : int
		{
			STGM_READ		= 0,
			STGM_WRITE		= 1,
			STGM_READWRITE	= 2,
		}
		
		public IStreamWrapper(Stream stream)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");
			m_stream = stream;
			m_pos = 0;
			m_sync = new Object();
		}

		protected IStreamWrapper(IStreamWrapper streamWrapper)
		{
			m_stream = streamWrapper.m_stream;
			m_pos = streamWrapper.m_pos;
			m_sync = streamWrapper.m_sync;
		}


#region IStream implementation

		void IStream.Clone(out IStream clone)
		{
			clone = new IStreamWrapper(this);
			if (clone == null)
				throw new ArgumentNullException("StreamWrapper");
		}

		void IStream.Commit(int commitFlags)
		{
		}

		void IStream.CopyTo(IStream dest, long cb, IntPtr pcbRead, IntPtr pcbWritten)
		{
		}

		void IStream.LockRegion(long offset, long cb, int lockType)
		{
		}

		void IStream.Read(byte[] pv, int cb, IntPtr pcbRead)
		{
			int cbRead = 0;
			lock (m_sync)
			{
				try
				{
					m_stream.Seek(m_pos, SeekOrigin.Begin);
					cbRead = m_stream.Read(pv, 0, cb);
					if (cbRead > 0)
						m_pos += cbRead;
				}
				catch { }
			}
			if (pcbRead != IntPtr.Zero)
				Marshal.WriteInt32(pcbRead, cbRead);
		}
		
		void IStream.Revert()
		{
		}
		
		void IStream.Seek(long move, int origin, IntPtr newPos)
		{
			m_pos = m_stream.Seek(move, (SeekOrigin)origin);
			if (newPos != IntPtr.Zero)
				Marshal.WriteInt64(newPos, m_pos);
		}
		
		void IStream.SetSize(long libNewSize)
		{
		}
		
		void IStream.Stat(out System.Runtime.InteropServices.ComTypes.STATSTG statStg, int statFlag)
		{
			statStg = new System.Runtime.InteropServices.ComTypes.STATSTG();

			statStg.type = (int)STGTY.STGTY_STREAM;
			statStg.cbSize = m_stream.Length;
			statStg.grfMode = 0; // default value for each flag will be false
			
			if (m_stream.CanRead && m_stream.CanWrite)
				statStg.grfMode |= (int)STGM.STGM_READWRITE;
			else if (m_stream.CanRead)
				statStg.grfMode |= (int)STGM.STGM_READ;
			else if (m_stream.CanWrite)
				statStg.grfMode |= (int)STGM.STGM_WRITE;
		}
		
		void IStream.UnlockRegion(long libOffset, long cb, int dwLockType)
		{
		}

		void IStream.Write(byte[] pv, int cbWrite, IntPtr pcbWritten)
		{
			lock (m_sync)
			{
				try
				{
					m_stream.Seek(m_pos, SeekOrigin.Begin);
					m_stream.Write(pv, 0, cbWrite);
					if (cbWrite > 0)
						m_pos += cbWrite;
				}
				catch { }
			}

			if (pcbWritten != IntPtr.Zero)
				Marshal.WriteInt32(pcbWritten, cbWrite);
		}

#endregion // IStream implementation

	}
}
