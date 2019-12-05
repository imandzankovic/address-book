import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { MatDialog, MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: "app-contact-discard",
  templateUrl: "./contact-discard.component.html",
  styleUrls: ["./contact-discard.component.scss"]
})
export class ContactDiscardComponent {
  constructor(
    private fb: FormBuilder,
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<ContactDiscardComponent>
  ) {} // Closing dialog window

  public cancel(): void {
    // To cancel the dialog window
    this.dialogRef.close();
  }

  public cancelN(): void {
    this.dialog.closeAll();
  }
}
