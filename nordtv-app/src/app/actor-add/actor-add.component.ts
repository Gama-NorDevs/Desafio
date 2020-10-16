import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActorService } from 'src/services/actor/actor.service';
import { Actor } from 'src/services/models/actor';

@Component({
  selector: 'app-actor-add',
  templateUrl: './actor-add.component.html',
  styleUrls: ['./actor-add.component.css']
})
export class ActorAddComponent implements OnInit {

  public actors: Array<any> = [];

  basicForm: FormGroup;

  constructor(private _actorService: ActorService) {

  }

  ngOnInit(): void {
    this.basicForm = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      email: new  FormControl(null, [Validators.required]),
      password: new  FormControl(null, [Validators.required]),
      profile: new  FormControl(null, [Validators.required]),
      amount: new  FormControl(null, [Validators.required]),
      sex: new  FormControl(null, [Validators.required]),
    });
  }

  onSubmit() {
    const actor = new Actor(this.basicForm.controls.name.value,
                          this.basicForm.controls.amount.value,
                          this.basicForm.controls.email.value,
                          this.basicForm.controls.password.value,
                          this.basicForm.controls.profile.value,
                          this.basicForm.controls.sex.value);

    const data = JSON.stringify(actor);

    this._actorService
        .InsertActor(JSON.parse(data))
        .subscribe(
          (response: any) => {
            alert('Dados inseridos com sucesso');
          },
          (error: any) => {
            alert('Erro ao inserir atores e/ou atrizes');
          }
        );
  }

}
