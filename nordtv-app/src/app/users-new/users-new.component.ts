import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/services/user/user.service';
import { User } from 'src/services/models/user';

@Component({
  selector: 'app-users-new',
  templateUrl: './users-new.component.html',
  styleUrls: ['./users-new.component.css']
})
export class UsersNewComponent implements OnInit {
  public users: Array<any> = [];

  basicForm: FormGroup;

  constructor(private _userService: UserService) {

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

  getUsers(): void
  {
    this._userService.getUsers()
        .subscribe(
          (response: any) => {
            this.users = response.data;
          },
          (error: any) => {
            alert('Erro ao carregar atores e/ou atrizes');
          }
        );
  }

  carregar(): void {
    this.getUsers();
  }

  onSubmit() {
    const user = new User(this.basicForm.controls.name.value,
                          this.basicForm.controls.amount.value,
                          this.basicForm.controls.email.value,
                          this.basicForm.controls.password.value,
                          this.basicForm.controls.profile.value,
                          this.basicForm.controls.sex.value);

    const data = JSON.stringify(user);

    this._userService
        .InsertUser(JSON.parse(data))
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

