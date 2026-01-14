[README EN-US](https://github.com/Falme/credits-template-unity/blob/main/README_EN-US.md) 👈

# Credits Template : Unity Edition

Template para a interface de créditos para seu jogo (na Unity) com as informações carregadas pelo JSON.

---

## Motivos?

Todo jogo deveria ter uma tela de créditos, mesmo que o jogo tenha sido desenvolvido por uma única pessoa, os criadores da obra devem ser registrados. O problema é que sempre precisamos criar uma nova cena para os créditos em cada jogo, e a tela de créditos é sempre diferente, porque cada jogo é diferente.

Assim, tendo isso em mente, não criei uma cena propriamente dita para os créditos, mas sim um modelo de interface dos créditos prontos para uso.

## Como Começar?

Baixe a versão mais recente do pacote `Credits-Unity-x-x-x.unitypackage` na [Página de Releases](https://github.com/Falme/credits-template-unity/releases) e importe para o seu projeto. 
- Clicar duas vezes no arquivo unitypackage, ou
- Na Unity, acesse `Assets > Import Package > Custom Package` e selecione o arquivo unitypackage.

Você deverá ter uma nova pasta no seguinte caminho: `Assets/Credits_Template`.

Agora, se você quiser um exemplo de como funciona, tenho uma cena em `Credits_Template/Scenes/Credits_Example.unity` (caso prefira aprender por meio de exemplos).

De qualquer forma, o modelo pode ser encontrado em `Credits_Template/prefabs/Credits_Canvas.prefab`, este é o modelo principal. Para usá-lo, basta adicioná-lo como um Canvas ou como filho de um Canvas gameobject, pois o modelo é 100% interface Canvas/UI.

Para alterar o conteúdo dos créditos, você precisará modificar o arquivo JSON em `Credits_Template/Data/credits.json`. Decidi colocar as informações em um arquivo JSON para que não apenas os desenvolvedores, mas qualquer membro da equipe, possa modificá-lo.

> **IMPORTANTE**: As dimensões de TUDO são definidas pelo componente "Canvas Scaler" no Canvas. Você deve definir uma Reference Resolution para o seu jogo e o tamanho da fonte. 

Para explicar rapidamente cada campo:

- title: Título da cena de créditos, normalmente o nome do jogo
- category: Categoria ou nome do cargo (exemplo: Produtores)
- actors: Nome da pessoa a ser listada (exemplo: Jane Doe)

Na próxima seção, explicaremos em mais detalhes a estrutura JSON.

## Estrutura JSON

Vou escrever um exemplo de créditos e explicar cada um deles com mais detalhes.

```json
{
	"velocity": 100.0,
	"title": "Super Jump Game 2: Electric Boogaloo",
	"labels": [
		[
			"Directors",
			"John Doe",
		],
		[
			"Producers",
			"Jane Doe"
			"Joe Mama",
			"Oscar Garlic"
		]
	]
}
```

Explicaremos cada campo de cima para baixo.

- velocity: Velocidade de rolagem dos créditos, velocidade de movimento
- title: Primeiro campo dos créditos, normalmente o nome do jogo
- labels: Pessoas que trabalharam no projeto e suas funções
    - Primeiro campo: Categoria, título do cargo
    - Outros campos: Nomes das pessoas que trabalharam no projeto na função especificada acima.

## Newtonsoft JSON DLL

Talvez você receba um erro relacionado ao JSON Newtonsoft. Isso pode acontecer por três motivos:

- Você não importou a pasta do plugin ao importar o unitypackage, faltando o arquivo DLL Newtonsoft.JSON.
- Você importou a pasta do plugin, mas tem outro arquivo Newtonsoft.JSON.dll no seu projeto, o que está causando um conflito.
- O CSharpMonoBehaviour não está encontrando a DLL. Se você estiver usando Assembly Definitions, basta adicionar uma referência do plugin Newtonsoft ao seu arquivo Asmdef.

Devido a problemas com a leitura e análise de JSON, injetei o Newtonsoft.JSON no pacote unity.
