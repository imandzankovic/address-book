import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ContactService } from "../contact.service";
import { Contact } from "../contact";
import { MatDialog } from '@angular/material/dialog';
import { ContactAddComponent } from '../contact-add/contact-add.component';

@Component({
  selector: "app-contact-detail",
  templateUrl: "./contact-detail.component.html",
  styleUrls: ["./contact-detail.component.scss"]
})
export class ContactDetailComponent implements OnInit {
  id: any;
  contact: Contact;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    public dialog: MatDialog,
    
  ) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(ContactAddComponent, {
      width: "640px",
      disableClose: true,
      data:this.contact
    });
   
 
  }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get("id");
    console.log(this.id)
    this.contactService.getContact(this.id).subscribe(res => {
      this.contact = res
    });
  }
}
