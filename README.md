[README EN-US](https://github.com/Falme/credits-template-unity/blob/main/README_EN-US.md) 👈

[Godot Engine Edition](https://github.com/Falme/credits-template-godot/) 👈

# Credits Template : Unity Edition

Template para a interface de créditos pro seu jogo (na Unity) carregadas por JSON.

---

## Motivos?

Todo jogo deveria ter uma tela de créditos, mesmo que o jogo tenha sido desenvolvido por uma única pessoa, os criadores da obra devem ser registrados. O problema é que sempre precisamos criar uma nova cena para os créditos em cada jogo, e a tela de créditos é sempre diferente, porque cada jogo é diferente.

Assim, tendo isso em mente, não criei uma cena propriamente dita para os créditos, mas sim um modelo de interface dos créditos prontos para uso.

## Como Começar?

Baixe a versão mais recente do pacote `Credits-Unity-x-x-x.unitypackage` na [Página de Releases](https://github.com/Falme/credits-template-unity/releases) e importe para o seu projeto. 
- Clicar duas vezes no arquivo unitypackage, ou
- Na Unity, acesse `Assets > Import Package > Custom Package` e selecione o arquivo unitypackage.

Você deverá ter duas novas pastas nos seguintes caminhos: 
- `Assets/Credits_Template`
- `Assets/StreamingAssets/Credits`

Agora, se você quiser um exemplo de como funciona, tenho uma cena em `Credits_Template/Scenes/Credits_Example.unity` (caso prefira aprender por meio de exemplos).

De qualquer forma, o modelo pode ser encontrado em `Credits_Template/prefabs/Credits_Canvas.prefab`, este é o modelo principal. Para usá-lo, basta arrastá-lo para uma cena ou como filho de um Canvas gameobject, pois o modelo é 100% interface Canvas/UI.

Para alterar o conteúdo dos créditos, você precisará modificar o arquivo JSON em `Credits_Template/Data/credits.json`. Decidi colocar as informações em um arquivo JSON para que não apenas os desenvolvedores, mas qualquer membro da equipe, possa modificá-lo.

> **IMPORTANTE**: As dimensões de TUDO são definidas pelo componente "Canvas Scaler" no Canvas. Você deve definir uma Reference Resolution para o seu jogo e o tamanho da fonte. 

Na próxima seção, explicaremos em mais detalhes a estrutura JSON.

## Estrutura JSON

Vou escrever um exemplo de créditos e explicar cada um deles com mais detalhes.

```json
{
	"version": "0.0.1",
	"velocity": 100.0,
	"items": [
		{
			"type": "title",
			"text": "Super Jump Game 2: \nThe Electric Boogaloo"
		},
		{
			"type": "space",
			"height": 100.0
		},
		{
			"type": "image", 
			"path": "Credits/example_image.png", 
			"height": 400
		},
		{
			"type": "category",
			"text": "Created By"
		},
		{
			"type": "actor",
			"actors": [
				"Falme Streamless"
			]
		},
		{
			"type": "space",
			"height": 100.0
		},
		{
			"type": "category",
			"text": "Special Thanks"
		},
		{
			"type": "actor",
			"actors": [
				"Alex Arroyo",
				"Danilo Cavedon",
				"Ruan Lima",
				"And everyone who shared this project!"
			]
		}
	]
}
```

Explicaremos cada campo de cima para baixo.

- version: Se você quiser acompanhar a versão dos créditos do seu jogo (não aparece na tela)
- velocity: Velocidade de rolagem dos créditos, velocidade de movimento
- items: Array contendo todos os objetos que podem ser adicionados aos créditos
	- title: Texto especial, geralmente o primeiro campo dos créditos e normalmente o nome do jogo
	- image: Uma imagem para ser adicionada aos créditos
		- path: Endereço/caminho para a imagem (base é "Assets/StreamingAssets/")
		- height: altura da imagem a ser exibida. A largura é proporcional ao tamanho original.
    - space: espaço vazio, uma margem entre uma label e outra label
		- height: altura do espaço a ser exibido
    - category: o título do cargo
	- actor: Nomes daqueles que trabalharam no projeto na função especificada acima.
		- actors: Array de nomes. Tente não colocar muitos nomes em um único array, divida para melhor desempenho.

## Erros no Newtonsoft.JSON

Este projeto requer o Newtonsoft.JSON. No momento, ele não está incluído no pacote unitypackage, então você precisará instalá-lo usando o Package Manager. É simples:

1. Vá em `Window > Package Management > Package Manager` pra abrir o Package Manager
2. Clique no Sinal de Mais `+ > Install package by name...`
3. Digite o endereço da Newtonsoft no campo name:
	- `com.unity.nuget.newtonsoft-json@3.0`
4. Aguarde a instalação. 

Se a Signature reproduzir um erro, atualize sua versão do Unity. Isso resolverá o problema.
