import { Component, OnInit, Inject } from '@angular/core';
import { ILogin } from '../../shared/interface/login.model';
import { Router } from '@angular/router';

import { ToastService } from '../../core/services/toast.service';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClientService } from 'src/app/core/services/client.service';
import { Customer } from 'src/app/shared/interface/project';
import { ProjectService } from 'src/app/core/services/project.service';

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  isDisable: boolean = true;
  formData!: FormGroup;

  // data register

  name: string = '';
  phone: string = '';
  gender: string = '';
  mail: string = '';

  passwords: string = '';
  confirmPass: string = '';
  birthday: string = '';
  // data register

  //// data check

  passwordMismatch: boolean = false;

  //// data check

  constructor(
    private fb: FormBuilder,
    private loginSer: ClientService,
    private clientSer: ClientService,
    private toast: ToastService,
    private router: Router,

    public dialogRef: MatDialogRef<LoginComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}

  ngOnInit(): void {
    this.formData = this.fb.group({
      userNameOrEmailAddress: ['', Validators.compose([Validators.required])],
      password: [
        '',
        Validators.compose([Validators.required, Validators.minLength(5)]),
      ],
      rememberClient: [false],
    });
  }

  getData(): ILogin {
    return {
      userNameOrEmailAddress: this.formData.value.userNameOrEmailAddress,
      password: this.formData.value.password,
      rememberClient: true,
    };
  }

  validateEmpty() {
    const userName = (
      document.querySelector('input[type="email"]') as HTMLInputElement
    ).value;
    const userPassword = (
      document.querySelector('input[type="password"]') as HTMLInputElement
    ).value;
    userName !== '' && userPassword !== ''
      ? (this.isDisable = false)
      : (this.isDisable = true);
  }

  onSubmit() {
    const mail = this.formData.value.userNameOrEmailAddress;
    const pass = this.formData.value.password;

    console.warn(this.formData.value.userNameOrEmailAddress);
    console.warn(this.formData.value.password);
    this.loginSer.getLogin(mail, pass);
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  openForgetPass() {
    console.warn('forget');
  }

  register() {
    if (!this.passwordMismatch) {
      if (!this.validateEmail(this.mail)) {
        this.toast.showError('Thông báo', 'email không hợp lệ');
        return;
      } else if (this.name == '' || this.name.length < 3) {
        this.toast.showError('Thông báo', 'tên không hợp lệ');
        return;
      } else if (this.passwords == '' || this.passwords.length < 5) {
        this.toast.showError('Thông báo', 'password không hợp lệ');
        return;
      }

      this.clientSer.createCustomer(
        new Customer(
          this.name,
          this.birthday,
          'HCM',
          this.phone,
          parseInt(this.gender),
          this.mail,
          this.passwords
        )
      );
    }
  }
  checkPasswordMatch() {
    if (this.passwords !== this.confirmPass) {
      this.passwordMismatch = true;
    } else {
      this.passwordMismatch = false;
    }
  }
  validateEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }
}
