import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersNewComponent } from './users-new.component';


const routes: Routes = [
  {
    path: '',
    component: UsersNewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersNewRoutingModule { }
