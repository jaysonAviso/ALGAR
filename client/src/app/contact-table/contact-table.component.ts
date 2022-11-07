import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from '../_models/contact';
import { ContactService } from '../_services/contact.service';

@Component({
  selector: 'app-contact-table',
  templateUrl: './contact-table.component.html',
  styleUrls: ['./contact-table.component.css']
})
export class ContactTableComponent implements OnInit {
  contacts: Contact[];

  constructor(private contactService: ContactService, private router: Router) { }

  ngOnInit() {
    this.getContacts();
  }

  getContacts(){
    this.contactService.getContacts().subscribe(contacts => {
      this.contacts = contacts;
    })
  }

  deleteContact(id: number) {
    if(confirm("Are your sure Do you want to delete")){
    this.contactService.deleteContact(id).subscribe(() => {
      console.log("Deleted Contact");
      this.getContacts();
      });
    }
  }

  searchContact() {
    const lastname = document.getElementById('lastname') as HTMLInputElement;

    this.contactService.getContactByLastname(lastname.value).subscribe(contacts => {
      this.contacts = contacts;
    });

    // if(lastname.value !== ""){
    //     this.router.navigateByUrl('/contactForm/lastname/' + lastname.value);
    // }else {
    //   console.log("lastname not match");
    // }
  }

}
