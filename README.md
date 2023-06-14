# Commission Factory Modernisation Challenge: ModernisationChallengeVT
# VT means "Vu Tran"

I would like to describe about my custom

Backend:
I applied the Onion architecture. It has 3 parts
1. Core business:
- ModernisationChallengeVT.Domain: it is the entities of the business, the soft delete entity or the auditable entity. It supplies the interfaces to interact with data.
- ModernisationChallengeVT.Contract: it defines DTOs, define the business action concepts. The world will use our app via the Contract.
- ModernisationChallengeVT.Business: it implements the IBussiness from Contract. Most of thing will do here because we implement the business logic here.
2. Infrastructure:
- ModernisationChallengeVT.Persistence: it create a brige from the Domain to the database server (SQLServer). 
  - It also configs for auditable entities because I want to separate between the business logic in Business and the configuration of auditable fields in Persistence.
  - For example: when we update a details of a task, I want to code update the Details only. The developer doesn't need to care about update ModifiedDate. That data is updated automatically by configuration.
3. Presentation: ModernisationChallengeVT.WebAPI
- Just exposing the api and registering DI.

Fronted:
- I applied Vuejs because I want to prove that I can learn other framework.
- It is quite simple. There 2 components: TaskList.vue and TaskDetail.vue
- TaskList.vue: listing the current tasks, handle delete action and complete action. When creating or updating, it will call the child route: TaskDetail.vue
- TaskDetail.vue: displaying as modal.
- The CSS, I just put in App.vue (I know it is not good)


Technical debt:
- When cancelling create/update, a request occurs to reload the TaskList -> I'm still finding the other way to initilize the modal.

How to run:
- Please open the .sln file by Visual Studio .MordernisationChallengeVT/MordernisationChallengeVT/MordernisationChallengeVT.sln
- The Run the project
- Open the Frontend Vue project
- Open CMD and type "npm install". After that please run "npm run serve" to open the client site.
- Open the site http://localhost:8080/ . We can use now.

Thanks.
