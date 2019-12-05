import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators
} from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ContactDiscardComponent } from "../contact-discard/contact-discard.component";
import { Contact } from "../contact";
import { ContactService } from "../contact.service";

@Component({
  selector: "app-contact-edit",
  templateUrl: "./contact-edit.component.html",
  styleUrls: ["./contact-edit.component.scss"]
})
export class ContactEditComponent implements OnInit {
  public breakpoint: number; // Breakpoint observer code
  public addContactForm: FormGroup;
  contact = new Contact();
  wasFormChanged = false;
  errorMessage: string;

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private contactService: ContactService
  ) {}

  public ngOnInit(): void {
    this.addContactForm = this.fb.group({
      IdProof: null,
      firstname: [
        "",
        [Validators.required, Validators.pattern("[a-zA-Z]+([a-zA-Z ]+)*")]
      ],
      lastname: [
        "",
        [Validators.required, Validators.pattern("[a-zA-Z]+([a-zA-Z ]+)*")]
      ],
      phone: [
        "",
        [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]
      ],
      email: [""]
    });
    this.breakpoint = window.innerWidth <= 600 ? 1 : 2; // Breakpoint observer code
  }

  public onAddContact(): void {
    this.markAsDirty(this.addContactForm);
    this.saveContact();
  }

  saveContact(): void {
    console.log(this.addContactForm.value);

    if (this.addContactForm.valid) {
      if (this.addContactForm.dirty) {
        const c = { ...this.contact, ...this.addContactForm.value };

        if (c.id === undefined) {
          this.contactService.createContact(c).subscribe(
            () => this.onSaveComplete(),
            (error: any) => (this.errorMessage = <any>error)
          );
        } else {
          this.contactService.updateContact(c).subscribe(
            () => this.onSaveComplete(),
            (error: any) => (this.errorMessage = <any>error)
          );
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = "Please correct the validation errors.";
    }
  }

  onSaveComplete(): void {
    this.dialog.closeAll();
  }

  openDialog(): void {
    console.log(this.wasFormChanged);
    if (this.addContactForm.dirty) {
      const dialogRef = this.dialog.open(ContactDiscardComponent, {
        width: "340px"
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
