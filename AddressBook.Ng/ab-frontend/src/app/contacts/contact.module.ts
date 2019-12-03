import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ContactDetailComponent } from "./contact-detail/contact-detail.component";
import { RouterModule } from "@angular/router";
import { ContactListComponent } from "./contact-list.component";

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
    CommonModule
  ],

  declarations: [ContactDetailComponent]
})
export class ContactModule {}
