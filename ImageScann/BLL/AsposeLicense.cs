using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace ImageScann.BLL
{

    public static class AsposeLicense {

        static AsposeLicense() {
            ModifyInMemory.ActivateMemoryPatching();
        }

        public static void ConfigKey() { }

        private static class ModifyInMemory {

            public static void ActivateMemoryPatching() {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies.Where(assembly => assembly.FullName.StartsWith("Aspose."))) {
                    ActivateForAssembly(assembly);
                }

                AppDomain.CurrentDomain.AssemblyLoad += ActivateOnLoad;
            }

            private static void ActivateOnLoad(object sender, AssemblyLoadEventArgs e) {
                var assembly = e.LoadedAssembly;
                var name = assembly.FullName;
                if (name.StartsWith("Aspose.")) {
                    ActivateForAssembly(assembly);
                }
            }

            // ReSharper disable once CyclomaticComplexity
            // ReSharper disable once FunctionComplexityOverflow
            private static void ActivateForAssembly(Assembly assembly) {
                const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;
                var method1 = typeof(ModifyInMemory).GetMethod(nameof(InvokeMe1), flags);
                var method2 = typeof(ModifyInMemory).GetMethod(nameof(InvokeMe2), flags);
                var miDict = new Dictionary<string, MethodInfo> { { "System.DateTime", method1 }, { "System.Xml.XmlElement", method2 } };
                Type[] types;
                var isFound = false;
                var nCount = 0;
                try {
                    types = assembly.GetTypes();
                } catch (ReflectionTypeLoadException e) {
                    types = e.Types;
                }

                foreach (var type in types) {
                    if (isFound) {
                        break;
                    }

                    if (type == null) {
                        continue;
                    }

                    var arrMInfo = type.GetMethods(flags);
                    foreach (var info in arrMInfo) {
                        try {
                            var strMethod = info.ToString();
                            if (strMethod.IndexOf("(System.Xml.XmlElement, System.String)", StringComparison.Ordinal) <= 0 ||
                                info.ReturnType.ToString() == "System.String") {
                                continue;
                            }

                            MemoryPatching(info, miDict[info.ReturnType.ToString()]);
                            nCount++;
                            if (assembly.FullName.IndexOf("Aspose.Pdf", StringComparison.OrdinalIgnoreCase) == -1 && nCount == 2 ||
                                assembly.FullName.IndexOf("Aspose.Pdf", StringComparison.OrdinalIgnoreCase) != -1 && nCount == 4) {
                                isFound = true;
                                break;
                            }
                        } catch (Exception exception) {
                            throw new InvalidOperationException("MemoryPatching for " + assembly.FullName + " failed !", exception);
                        }
                    }
                }

                var aParts = assembly.FullName.Split(',');
                var fName = aParts[0];
                if (fName.IndexOf("Aspose.BarCode.", StringComparison.Ordinal) != -1) {
                    fName = "Aspose.BarCode";
                } else if (fName.IndexOf("Aspose.3D", StringComparison.Ordinal) != -1) {
                    fName = "Aspose.ThreeD";
                } else if (fName.IndexOf("Aspose.PDF", StringComparison.Ordinal) != -1) {
                    fName = "Aspose.Pdf";
                }

                try {
                    var type2 = assembly.GetType(fName + ".License");
                    var mi = type2.GetMethod("SetLicense", new[] { typeof(Stream) });
                    if (mi == null) {
                        return;
                    }

                    // ReSharper disable StringLiteralTypo
                    var LData = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLT" +
                                "giPz4KPExpY2Vuc2U+CiAgPERhdGE+CiAgICA8TGljZW5z" +
                                "ZWRUbz5MaWNlbnNlZTwvTGljZW5zZWRUbz4KICAgIDxFbW" +
                                "FpbFRvPmxpY2Vuc2VlQGVtYWlsLmNvbTwvRW1haWxUbz4K" +
                                "ICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaW" +
                                "NlbnNlVHlwZT4KICAgIDxMaWNlbnNlTm90ZT5MaW1pdGVk" +
                                "IHRvIDEwMDAgZGV2ZWxvcGVyLCB1bmxpbWl0ZWQgcGh5c2" +
                                "ljYWwgbG9jYXRpb25zPC9MaWNlbnNlTm90ZT4KICAgIDxP" +
                                "cmRlcklEPjc4NDM3ODU3Nzg1PC9PcmRlcklEPgogICAgPF" +
                                "VzZXJJRD4xMTk3ODkyNDM3OTwvVXNlcklEPgogICAgPE9F" +
                                "TT5UaGlzIGlzIGEgcmVkaXN0cmlidXRhYmxlIGxpY2Vuc2" +
                                "U8L09FTT4KICAgIDxQcm9kdWN0cz4KICAgICAgPFByb2R1" +
                                "Y3Q+QXNwb3NlLlRvdGFsIFByb2R1Y3QgRmFtaWx5PC9Qcm" +
                                "9kdWN0PgogICAgPC9Qcm9kdWN0cz4KICAgIDxFZGl0aW9u" +
                                "VHlwZT5FbnRlcnByaXNlPC9FZGl0aW9uVHlwZT4KICAgID" +
                                "xTZXJpYWxOdW1iZXI+e0YyQjk3MDQ1LTFCMjktNEIzRi1C" +
                                "RDUzLTYwMUVGRkExNUFBOX08L1NlcmlhbE51bWJlcj4KIC" +
                                "AgIDxTdWJzY3JpcHRpb25FeHBpcnk+MjA5OTEyMzE8L1N1" +
                                "YnNjcmlwdGlvbkV4cGlyeT4KICAgIDxMaWNlbnNlVmVyc2" +
                                "lvbj4zLjA8L0xpY2Vuc2VWZXJzaW9uPgogIDwvRGF0YT4K" +
                                "ICA8U2lnbmF0dXJlPlFYTndiM05sTGxSdmRHRnNJRkJ5Yj" +
                                "JSMVkzUWdSbUZ0YVd4NTwvU2lnbmF0dXJlPgo8L0xpY2Vu" +
                                "c2U+";
                    // ReSharper restore StringLiteralTypo
                    Stream stream = new MemoryStream(Convert.FromBase64String(LData));
                    stream.Seek(0, SeekOrigin.Begin);
                    mi.Invoke(Activator.CreateInstance(type2, null), new object[] { stream });
                } catch (Exception e) {
                    throw new InvalidOperationException("SetLicense for " + assembly.FullName + " failed !", e);
                }
            }

            // ReSharper disable UnusedParameter.Local
            private static DateTime InvokeMe1(XmlElement element, string name) => new DateTime(2099, 12, 31);
            // ReSharper restore UnusedParameter.Local

            private static XmlElement InvokeMe2(XmlElement element, string name) {
                if (element.LocalName == "License") {
                    // ReSharper disable StringLiteralTypo
                    var License64 = "PERhdGE+PExpY2Vuc2VkVG8+R3JvdXBEb2NzPC9MaWNlbnN" +
                                    "lZFRvPjxMaWNlbnNlVHlwZT5TaXRlIE9FTTwvTGljZW5zZV" +
                                    "R5cGU+PExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMTAgZGV2Z" +
                                    "WxvcGVyczwvTGljZW5zZU5vdGU+PE9yZGVySUQ+MTMwNzI0" +
                                    "MDQwODQ5PC9PcmRlcklEPjxPRU0+VGhpcyBpcyBhIHJlZGl" +
                                    "zdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+PFByb2R1Y3RzPj" +
                                    "xQcm9kdWN0PkFzcG9zZS5Ub3RhbDwvUHJvZHVjdD48L1Byb" +
                                    "2R1Y3RzPjxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl0" +
                                    "aW9uVHlwZT48U2VyaWFsTnVtYmVyPjliNTc5NTAxLTUyNjE" +
                                    "tNDIyMC04NjcwLWZjMmQ4Y2NkZDkwYzwvU2VyaWFsTnVtYm" +
                                    "VyPjxTdWJzY3JpcHRpb25FeHBpcnk+MjAxNDA3MjQ8L1N1Y" +
                                    "nNjcmlwdGlvbkV4cGlyeT48TGljZW5zZVZlcnNpb24+Mi4y" +
                                    "PC9MaWNlbnNlVmVyc2lvbj48L0RhdGE+PFNpZ25hdHVyZT5" +
                                    "udFpocmRoL3I0QS81ZFpsU2dWYnhac0hYSFBxSjZ5UVVYa0" +
                                    "RvaW4vS2lVZWhUUWZET0lQdHdzUlR2NmRTUVplOVdXekNnV" +
                                    "3RGdkdROWpmR2QySmF4YUQvbkx1ZEk2R0VVajhqeVhUMG4v" +
                                    "bWRrMEF1WVZNYlBXRjJYd3dSTnFlTmRrblYyQjhrZVFwbDJ" +
                                    "2RzZVbnhxS2J6VVFxS2Rhc1pzZ2w1Q0xqSFVEWms9PC9TaW" +
                                    "duYXR1cmU+";
                    // ReSharper restore StringLiteralTypo
                    element.InnerXml = new UTF8Encoding().GetString(Convert.FromBase64String(License64));
                }

                if (element.LocalName == "BlackList") {
                    // ReSharper disable StringLiteralTypo
                    var BlackList64 = "PERhdGE+PC9EYXRhPjxTaWduYXR1cmU+cUJwMEx1cEVoM1Zn" +
                                      "OWJjeS8vbUVXUk9KRWZmczRlY25iTHQxYlNhanU2NjY5RHla" +
                                      "d09FakJ1eEdBdVBxS1hyd0x5bmZ5VWplYUNGQ0QxSkh2RVUx" +
                                      "VUl5eXJOTnBSMXc2NXJIOUFyUCtFbE1lVCtIQkZ4NFMzckFV" +
                                      "Mnd6dkxPZnhGeU9DQ0dGQ2UraTdiSHlGQk44WHp6R1UwdGRP" +
                                      "MGR1RTFoRTQ5M1RNY3pRPTwvU2lnbmF0dXJlPg==";
                    // ReSharper restore StringLiteralTypo
                    element.InnerXml = new UTF8Encoding().GetString(Convert.FromBase64String(BlackList64));
                }

                var elementsByTagName = element.GetElementsByTagName(name);
                if (elementsByTagName.Count <= 0) {
                    return null;
                }

                return (XmlElement)elementsByTagName[0];
            }

            private static unsafe void MemoryPatching(MethodBase miEvaluation, MethodBase miLicensed) {
                var intPtrEval = GetMemoryAddress(miEvaluation);
                var intPtrLicensed = GetMemoryAddress(miLicensed);
                if (IntPtr.Size == 8) {
                    *(long*)intPtrEval.ToPointer() = *(long*)intPtrLicensed.ToPointer();
                } else {
                    *(int*)intPtrEval.ToPointer() = *(int*)intPtrLicensed.ToPointer();
                }
            }

            private static unsafe IntPtr GetMemoryAddress(MethodBase mb) {
                RuntimeHelpers.PrepareMethod(mb.MethodHandle);
                if (Environment.Version.Major >= 4 ||
                    Environment.Version.Major == 2 &&
                    Environment.Version.MinorRevision >= 3053) {
                    return new IntPtr((int*)mb.MethodHandle.Value.ToPointer() + 2);
                }

                var location = (ulong*)mb.MethodHandle.Value.ToPointer();
                var index = (int)((*location >> 32) & 0xFF);
                if (IntPtr.Size == 8) {
                    Debug.Assert(mb.DeclaringType != null, "mb.DeclaringType != null");
                    var classStart = (ulong*)mb.DeclaringType.TypeHandle.Value.ToPointer();
                    var address = classStart + index + 10;
                    return new IntPtr(address);
                } else {
                    Debug.Assert(mb.DeclaringType != null, "mb.DeclaringType != null");
                    var classStart = (uint*)mb.DeclaringType.TypeHandle.Value.ToPointer();
                    var address = classStart + index + 10;
                    return new IntPtr(address);
                }
            }

        }

    }

}
