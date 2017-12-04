' 注意: 使用上下文菜单上的“重命名”命令可以同时更改代码和配置文件中的接口名“IService1”。
<ServiceContract()>
Public Interface IService1

    <OperationContract()>
    Function GetData(ByVal value As Integer) As String

    <OperationContract()>
    Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

    ' TODO: 在此添加您的服务操作

End Interface

' 使用下面示例中说明的数据约定将复合类型添加到服务操作。
' 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“WcfServiceLibrary1.ContractType”直接使用其中定义的数据类型。

<DataContract()>
Public Class CompositeType

    <DataMember()>
    Public Property BoolValue() As Boolean

    <DataMember()>
    Public Property StringValue() As String

End Class
