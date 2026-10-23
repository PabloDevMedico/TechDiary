# SystemSchool

Aplicação desktop de gestão escolar desenvolvida em C# com Windows Forms, .NET Framework 4.7.2 e SQL Server.

## Projeto principal

A solução `SystemSchool.slnx` aponta para o projeto:

```text
Tech_Diary01/Tech_Diary01.csproj
```

## Banco de dados

Para criar uma base nova, utilize:

```text
BancoDadosCorrigido.sql
```

Para atualizar uma base já existente com as estruturas das telas novas, utilize:

```text
AtualizarBancoParaNovasTelas.sql
```

Antes de executar a aplicação, ajuste a conexão local em:

```text
Tech_Diary01/Data/Connection.cs
```

## Requisitos

- Windows com Visual Studio compatível com .NET Framework 4.7.2
- SQL Server ou SQL Server Express
- Pacotes NuGet restaurados pelo Visual Studio

## Aviso

O script de criação contém usuários exclusivamente demonstrativos. Para uso real, substitua-os e implemente armazenamento seguro de senhas com hash.
