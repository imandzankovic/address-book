import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ContactDetailComponent } from "./contact-detail/contact-detail.component";
import { RouterModule } from "@angular/router";
import { ContactListComponent } from "./contact-list.component";
import { ContactEditComponent } from './contact-edit/contact-edit.component';
import { ContactDiscardComponent } from './contact-discard/contact-discard.component';
import { AngularMaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: "contacts", component: ContactListComponent },
      {
        path: "contacts/:id",
        //canActivate: [ContactDetailGuard],
        component: ContactDetailComponent
      }
    ]),
    CommonModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],

  declarations: [ContactDetailComponent, ContactEditComponent, ContactDiscardComponent]
})
export class ContactModule {}
