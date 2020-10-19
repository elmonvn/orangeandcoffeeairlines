OrangeAndCoffeeAirlines
=======================
Plataforma de vendas e reservas de passagens aéreas, integrado com meio de pagamento.

 ###### Papéis: Regina = PO, Elmon = SM, Marco + Elmon + Gleydson + Wladigley = Dev Team
--
### Sumary
* [Sobre a Equipe](OCAirlines/README.md)
* [Metodologia - Scrum](OCAirlines/README.md)
* [Sobre o Projeto](OCAirlines/README.md)
---




## Sobre a Equipe
---
#### Elmon
>Experiência em grandes projetos de desenvolvimento noutras tecnologias e Marco com familiaridade em plataforma .Net
>**Fortalezas:** Disposição permanente para novos desafios e aprendizados, experiência em consultoria de TI, espírito de equipe
>**Pontos de melhoria:** Pouca experiência em metodologias ágeis, gestão do tempo

#### Marco:
>Larga experiência em projetos comerciais, industriais no ramo de software bem como já desenvolveu em .Net
>**Fortalezas:** Flexibilidade, criatividade, resiliente, autodidata e espírito de equipe.
>**Pontos de melhoria:** Preciso de experiência em DevOps e Docker

#### Gleydson:
>Graduado em Ciência da Computação pela Universidade Federal da Paraíba, com experiência de mais de 3 anos com .NET.
>**Fortalezas:** Liderança, criatividade, diciplina, dedicado, flexível, adaptável
>**Pontos de melhoria:** Pouca experiência com DevOps

#### Wladigley (Digley):
>Graduado em analise e desenvolvimento de sistemas, entusiasta e estudioso de novas tecnologias e metódos.Principal expetise com a plataformas .net e Javascript com React.Bastante experiencia com sistemas comerciais e migração de tecnologias.
>**Fortalezas:** Criativo, metódico, resiliente, compromissado, bastante estudioso, autruista e boa relação em equipe.
>**Pontos de melhoria:** Exercicio de Liderança, Acertividade em esforço de demandas e me aprimorar em tecnologias mobile.

## Metodologia - Scrum
---
Cerimônias acompanhadas no AzureDevops:
>https://dev.azure.com/orangeandcoffee/orangeandcoffeeairlines/_workitems

#### 1º Reunião de planning (kick-off) - pauta:
  - elaboração do PRoduct Backlog: participantes, PO, SM, Dev Team
  - decidida duração de sprints de 1 semana útil (5 dias)

#### Sprint 1: 
**5 a 9 de Outuubro de 2020**
  - sprint planning: resultado = sprint 1 backlog 5/10
  - implementação da sprint 5 a 9/10
  - dailies
  - sprint review 10/10
  - sprint retrospective 10/10

#### Sprint 2:
**12 a 16 de Outuubro de 2020**
  - sprint planning: resultado = sprint 2 backlog 12/10
  - implementação da sprint 12 a 16/10
  - dailies
  - sprint review 17/10
  - sprint retrospective 17/10


#### Detalhes:
>  - cerimônias: online entre os membros da equipe. Planning, review e restrospective com duração de 1h antes das aulas noturnas, nas datas citadas. Dailies ocorrendo pelas manhãs, com duração de 15min, diariamente, no decorrer das sprints.
>  - artefatos: foi selecionada a ferramenta Boards do Azure DevOps como meio de registro do Product Backlog, dos Sprint backlogs e das tasks das sprints. Há uma integração das tasks e do repositório do código do sistema através da ferramenta Repos, também do serviço Azure DevOps. As reviews têm como entrada a disponibilização do sistema no serviço de nuvem Azure, e orquestração pela ferramenta Pipelines do Azure DevOps.
>
## Sobre o Projeto
---
>A plataforma OrangeAndCoffeeAirlines foi construida pensando no principio de responsabilidade de cada serviço que compõe:

### Back-end
  * **Api OCAirLines.Authentication**
    Desenvolvida para prover token de seguraça/autenticação para os outros serviços. 
    
  * **Api OCAirLines.Pagamento**
    Desenvolvida para prover todo meio de pagamento da plataforma.
    
  * **Api OCAirLines.Passagem**
    Desenvolvida para prover integração com as mais diferentes companhia areas.
    
  * **Api OCAirLines.WebAPI**
    Desenvolvida para prover gerenciamento de cadastro e perfil do usuarios da plataforma.
    
**TecNologias empregadas:**
* .NetCore 3.1
* EntityFramework
* Migrations
* Token JWT
* X-Unit - Tests
* SeriLogs - Logs
* SwashBuckler - swagger openApi

### Front-end
  * **OCAirLinesFront**
    Desenvolvida para prover melhor experiacia do usuario na compra de passagens. 
  
**TecNologias empregadas:**
* Angular
* MaterialUI

