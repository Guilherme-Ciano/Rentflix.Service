# Sobre o Projeto

OBJETIVO: CRIAR UM SISTEMA DE GESTÃO DE LOCAÇÕES DE FILMES RESPEITANDO OS REQUISITOS SOLICITADOS

O projeto se baseia na em um sistema de gestão escolar, com uma fácil curva de aprendizado para pessoas com menos experiencias em tecnologias e que motive o aluno a buscar evoluir, dando para ele pontos para evoluir seu perfil e "badgets" para cada meta ou desafio cumprido

## Variáveis de Ambiente

Para rodar esse projeto localmente, você precisará de:

- MySQl server (recomendado: Workbench)
- Dotnet V6 ou superior

---

Execute os seguintes comandos após baixar todas as dependências anteriormente solicitadas

```bash
    cd Rentflix.Service/
    dotnet restore
    dotnet debug
```

## Criando a imagem Docker

Abra o seu terminal (particularmente, prefiro usar o bash, então recomendo o mesmo para atingir o resultado esperado)

```bash
  docker build -t rentflix -f Dockerfile .
```

## Aprendizados

O que você aprendeu construindo esse projeto? Quais desafios você enfrentou e como você superou-os?

## Libs do projeto e seus devidos usos

| Lib           | Funcionalidade                                                                                 |
| ------------- | ---------------------------------------------------------------------------------------------- |
| cypress       | testes de performance                                                                          |
| jest          | testes unitários de integração                                                                 |
| webpack       | minificação de códigos para build                                                              |
| sass          | criação de estilos de maneira mais fácil e menos verbosa                                       |
| mui           | componentes reutilizaveis para melhor otimização de tempo                                      |
| chakra-ui     | templates facilmente trabalhados para melhor gerencia de tempo e planejamento de nova features |
| react-icons   | icones para criar e personalizar o sistema de forma orgânica e dinâmica                        |
| redux-toolkit | gerenciamento de estado da aplicação + sintaxe mais clara                                      |

## Autores

- [@Guilherme-Ciano](https://www.github.com/guilherme-ciano)
