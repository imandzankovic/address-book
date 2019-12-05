import { Component, OnInit } from '@angular/core';
import { ContactService } from './contact.service';
import { Contact } from './contact';
import { MatDialog,MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ContactEditComponent } from './contact-edit/contact-edit.component';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})
export class ContactListComponent implements OnInit {
  errorMessage = '';
  filteredContacts : Contact[] = [];
  contacts: Contact[] = [];

  constructor(private contactService: ContactService,public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(ContactEditComponent,{
      width: '640px',disableClose: true 
    });
}
  ngOnInit() {
    this.contactService.getContacts().subscribe({
      next: contacts => {
        this.contacts = contacts;
        this.filteredContacts = this.contacts;
      },
      error: err => this.errorMessage = err
    });
  }

}
