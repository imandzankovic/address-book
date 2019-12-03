import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { WelcomeComponent } from "./home/welcome/welcome.component";
import { PageNotFoundComponent } from "./page-not-found.component";
import { ContactListComponent } from './contacts/contact-list.component';

@NgModule({
  imports: [
    RouterModule.forRoot([
      { path: "welcome", component: WelcomeComponent },
      { path: "", redirectTo: "welcome", pathMatch: "full" }, 
      { path: 'contacts', component: ContactListComponent },
      { path: "**", component: PageNotFoundComponent },
     
      // { path: 'notfound', component: PageNotFoundComponent },
      // { path: '**', redirectTo: '/notfound' }
    ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
