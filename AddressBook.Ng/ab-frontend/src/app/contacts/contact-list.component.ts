import { Component, OnInit } from '@angular/core';
import { ContactService } from './contact.service';
import { Contact } from './contact';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})
export class ContactListComponent implements OnInit {
  errorMessage = '';
  filteredContacts : Contact[] = [];
  contacts: Contact[] = [];

  constructor(private contactService: ContactService) { }

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
