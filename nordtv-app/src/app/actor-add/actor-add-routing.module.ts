import { NgModule } from '@angular/core';
import { ActorAddComponent } from './actor-add.component';
import { RouterModule, Routes } from '@angular/router';



const routes: Routes = [
  {
    path: '',
    component: ActorAddComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActorAddRoutingModule { }
