import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule as FormsModuleAngular, ReactiveFormsModule } from '@angular/forms';
import { ActorAddRoutingModule } from './actor-add-routing.module';
import { ActorAddComponent } from './actor-add.component';



@NgModule({
  declarations: [ActorAddComponent],
  imports: [
    CommonModule,
    ActorAddRoutingModule,
    FormsModuleAngular,
    ReactiveFormsModule
  ]
})
export class ActorAddModule { }
