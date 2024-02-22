# CoverletBugRepro
Minimal Reproduction of a Coverlet Bug

### Steps to reproduce the bug

These were performed in PowerShell 7.4.1 on Windows 11 23H2, but probably work with other combinations.

```ps1
dotnet tool restore
```

```ps1
dotnet build
```

```ps1
dotnet tool run coverlet -- MyLib.Tests\bin\Debug\net481\MyLib.Tests.dll -t dotnet -a "test --no-build" --verbosity detailed
```

### Output

```
TryWithCustomResolverOnDotNetCore for System.Data.SqlClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
Loading MyLib.Tests\bin\Debug\net481\MyLib.Tests.deps.json
Unable to instrument module: MyLib.Tests\bin\Debug\net481\MyLib.dll
Coverlet.Core.Exceptions.CecilAssemblyResolutionException: AssemblyResolutionException for 'System.Data.SqlClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. Try to add <PreserveCompilationContext>true</PreserveCompilationContext> to test projects </PropertyGroup> or pass '/p:CopyLocalLockFileAssemblies=true' option to the 'dotnet test' command-line
 ---> Mono.Cecil.AssemblyResolutionException: Failed to resolve assembly: 'System.Data.SqlClient, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
   --- End of inner exception stack trace ---
   at Coverlet.Core.Instrumentation.NetstandardAwareAssemblyResolver.TryWithCustomResolverOnDotNetCore(AssemblyNameReference name) in /_/src/coverlet.core/Instrumentation/CecilAssemblyResolver.cs:line 217
   at Coverlet.Core.Instrumentation.NetstandardAwareAssemblyResolver.Resolve(AssemblyNameReference name) in /_/src/coverlet.core/Instrumentation/CecilAssemblyResolver.cs:line 129
   at Mono.Cecil.MetadataResolver.Resolve(TypeReference type)
   at Mono.Cecil.ModuleDefinition.Resolve(TypeReference type)
   at Mono.Cecil.TypeReference.Resolve()
   at Mono.Cecil.Mixin.CheckedResolve(TypeReference self)
   at Mono.Cecil.MetadataBuilder.GetConstantType(TypeReference constant_type, Object constant)
   at Mono.Cecil.MetadataBuilder.AddConstant(IConstantProvider owner, TypeReference type)
   at Mono.Cecil.MetadataBuilder.AddParameter(UInt16 sequence, ParameterDefinition parameter, ParamTable table)
   at Mono.Cecil.MetadataBuilder.AddParameters(MethodDefinition method)
   at Mono.Cecil.MetadataBuilder.AddMethod(MethodDefinition method)
   at Mono.Cecil.MetadataBuilder.AddMethods(TypeDefinition type)
   at Mono.Cecil.MetadataBuilder.AddType(TypeDefinition type)
   at Mono.Cecil.MetadataBuilder.AddTypes()
   at Mono.Cecil.MetadataBuilder.BuildTypes()
   at Mono.Cecil.MetadataBuilder.BuildModule()
   at Mono.Cecil.MetadataBuilder.BuildMetadata()
   at Mono.Cecil.ModuleWriter.<>c.<BuildMetadata>b__2_0(MetadataBuilder builder, MetadataReader _)
   at Mono.Cecil.ModuleDefinition.Read[TItem,TRet](TItem item, Func`3 read)
   at Mono.Cecil.ModuleWriter.BuildMetadata(ModuleDefinition module, MetadataBuilder metadata)
   at Mono.Cecil.ModuleWriter.Write(ModuleDefinition module, Disposable`1 stream, WriterParameters parameters)
   at Mono.Cecil.ModuleWriter.WriteModule(ModuleDefinition module, Disposable`1 stream, WriterParameters parameters)
   at Mono.Cecil.ModuleDefinition.Write(Stream stream, WriterParameters parameters)
   at Coverlet.Core.Instrumentation.Instrumenter.InstrumentModule() in /_/src/coverlet.core/Instrumentation/Instrumenter.cs:line 325
   at Coverlet.Core.Instrumentation.Instrumenter.Instrument() in /_/src/coverlet.core/Instrumentation/Instrumenter.cs:line 148
   at Coverlet.Core.Coverage.PrepareModules() in /_/src/coverlet.core/Coverage.cs:line 143
Test run for D:\Projects\OGsys\CoverletBugRepro\MyLib.Tests\bin\Debug\net481\MyLib.Tests.dll (.NETFramework,Version=v4.8.1)
Microsoft (R) Test Execution Command Line Tool Version 17.9.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
Ascending
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 8 ms - MyLib.Tests.dll (net481)

Calculating coverage result...
  Generating report 'D:\Projects\OGsys\CoverletBugRepro\coverage.json'
+--------+------+--------+--------+
| Module | Line | Branch | Method |
+--------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 0%   | 0%     | 0%     |
+---------+------+--------+--------+
| Average | 0%   | 0%     | 0%     |
+---------+------+--------+--------+
```
