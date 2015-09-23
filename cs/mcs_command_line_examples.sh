# reference System.Numerics:
mcs -r:System.Numerics.dll compileMe.cs

# build a library (dll)
mcs -target:library libraryToCompile.cs
