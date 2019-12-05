import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ContactDeleteComponent } from '../contact-delete/contact-delete.component';
import { Contact } from '../contact';

@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.scss']
})
export class ContactEditComponent implements OnInit {
  public breakpoint: number; // Breakpoint observer code
  public addContactForm: FormGroup;
  contact = new Contact();  
  wasFormChanged = false;

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog
  ) { }

  public ngOnInit(): void {
    this.addContactForm = this.fb.group({
      IdProof: null,
      firstname: ['', [Validators.required, Validators.pattern('[a-zA-Z]+([a-zA-Z ]+)*')]],
      lastname: ['', [Validators.required, Validators.pattern('[a-zA-Z]+([a-zA-Z ]+)*')]],
      phone: [null, [Validators.required,  Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
      email: [null],
    });
    this.breakpoint = window.innerWidth <= 600 ? 1 : 2; // Breakpoint observer code
  }

  public onAddContact(): void {
    this.markAsDirty(this.addContactForm);
  }

  openDialog(): void {
    console.log(this.wasFormChanged);
    if(this.addContactForm.dirty) {
      const dialogRef = this.dialog.open(ContactDeleteComponent, {
        width: '340px',
      });
    } else {
      this.dialog.closeAll();
    }
  }

  // tslint:disable-next-line:no-any
  public onResize(event: any): void {
    this.breakpoint = event.target.innerWidth <= 600 ? 1 : 2;
  }

  private markAsDirty(group: FormGroup): void {
    group.markAsDirty();
    // tslint:disable-next-line:forin
    for (const i in group.controls) {
      group.controls[i].markAsDirty();
    }
  }

  formChanged() {
    this.wasFormChanged = true;
  }


}
