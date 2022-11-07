import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactTableComponent } from './contact-table/contact-table.component';

const routes: Routes = [
  {path: 'contactForm', component: ContactFormComponent},
  {path: 'contactForm/:id', component: ContactFormComponent},
  {path: 'contactForm/lastname/:lastname', component: ContactFormComponent},
  {path: 'contactTable', component: ContactTableComponent},
  {path: '**', component: ContactTableComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
