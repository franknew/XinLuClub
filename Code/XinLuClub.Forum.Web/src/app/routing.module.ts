import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { IndexComponent } from './components/client/index/index.component';
import { BoardtopiclistComponent } from './components/client/boardtopiclist/boardtopiclist.component';
import { LoginpageComponent } from './components/loginpage/loginpage.component';
import { TopiclistComponent } from './components/client/topiclist/topiclist.component';
import { NewesttopiclistComponent } from './components/client/newesttopiclist/newesttopiclist.component';
import { ActivetopiclistComponent } from './components/client/activetopiclist/activetopiclist.component';
import { TopicdetailComponent } from './components/client/topicdetail/topicdetail.component';
import { AdminpageComponent } from './components/admin/adminpage/adminpage.component';
import { UserComponent } from './components/admin/user/user.component';
import { BoardgroupComponent } from './components/admin/boardgroup/boardgroup.component';

const routes: Routes = [
    { path: 'login', component: LoginpageComponent },
    { path: 'admin', component: AdminpageComponent, children: [
      {
        path: 'userlist',
        outlet: 'admin',
        component: UserComponent,
      },
      {
        path: 'boardlist',
        outlet: 'admin',
        component: BoardgroupComponent,
      },
      {
        path: '',
        outlet: 'admin',
        component: UserComponent,
      },
    ] },
    { path: 'index', component: IndexComponent, children: [
      {
        path: 'topiclist/:id',
        outlet: 'forum',
        component: BoardtopiclistComponent,
      },
      {
        path: 'topicdetail/:id',
        outlet: 'forum',
        component: TopicdetailComponent,
      },
      {
        path: 'newestlist',
        outlet: 'forum',
        component: NewesttopiclistComponent,
        children:[

        ]
      },
      {
        path: 'activelist',
        outlet: 'forum',
        component: ActivetopiclistComponent,
        
      },
      {
        path: '',
        outlet: 'forum',
        component: ActivetopiclistComponent,
      },
      {
        path: '**',
        outlet: 'forum',
        component: ActivetopiclistComponent,
      }
    ] },
    {
      path: 'topiclist/:id',
      outlet: 'forum',
      component: BoardtopiclistComponent,
    },
    {
      path: 'topicdetail/:id',
      outlet: 'forum',
      component: TopicdetailComponent,
    },
    {
      path: 'newestlist',
      outlet: 'forum',
      component: NewesttopiclistComponent,
      children:[

      ]
    },
    {
      path: 'activelist',
      outlet: 'forum',
      component: ActivetopiclistComponent,
      
    },
    { path: '', component: IndexComponent},
    { path: '**', component: IndexComponent },
  ];
   
  @NgModule({
    imports: [ RouterModule.forRoot(routes,  { enableTracing: false }) ],
    exports: [ RouterModule ]
  })
  export class RoutingModule {}