
ImportConverterps.dll: dlldata.obj ImportConverter_p.obj ImportConverter_i.obj
	link /dll /out:ImportConverterps.dll /def:ImportConverterps.def /entry:DllMain dlldata.obj ImportConverter_p.obj ImportConverter_i.obj \
		kernel32.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \
.c.obj:
	cl /c /Ox /DREGISTER_PROXY_DLL \
		$<

clean:
	@del ImportConverterps.dll
	@del ImportConverterps.lib
	@del ImportConverterps.exp
	@del dlldata.obj
	@del ImportConverter_p.obj
	@del ImportConverter_i.obj
