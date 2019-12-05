import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-contact-delete',
  templateUrl: './contact-delete.component.html',
  styleUrls: ['./contact-delete.component.scss']
})
export class ContactDeleteComponent{

  constructor(private fb: FormBuilder,
    private dialog: MatDialog,
                  private dialogRef: MatDialogRef<ContactDeleteComponent>) {} // Closing dialog window
    
    public cancel(): void { // To cancel the dialog window
    this.dialogRef.close();
    }
    
    public cancelN(): void { 
        this.dialog.closeAll();
    }

}
