import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule as FormsModuleAngular, ReactiveFormsModule } from '@angular/forms';

import { UsersNewComponent } from './users-new.component';
import { UsersNewRoutingModule } from './users-new-routing.module';


@NgModule({
  declarations: [UsersNewComponent],
  imports: [
    CommonModule,
    UsersNewRoutingModule,
    FormsModuleAngular,
    ReactiveFormsModule
  ]
})
export class UsersNewModule { }
