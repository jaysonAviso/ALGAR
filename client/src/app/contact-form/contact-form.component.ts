import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '../_models/contact';
import { ContactService } from '../_services/contact.service';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {
  updateMode = true;
  contact: Contact;
  registerForm: FormGroup;

  constructor(private contactService: ContactService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.initializeForm();
    this.getContactById();
    
    // if (this.route.snapshot.paramMap.get('id') != null)
    //   this.getContactByUsername();
  }

  initializeForm() {
    this.registerForm = new FormGroup({
      lastname: new FormControl(),
      firstname: new FormControl(),
      phone: new FormControl(),
      email: new FormControl()
    });
  }

  getContactById() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id == null) {
      this.updateMode = false;
    } else {
      this.contactService.getContactById(parseInt(id)).subscribe(contact => {
      this.contact = contact;
      this.setContactValue();
    });
    }
  }

  // getContactByUsername() {
  //   const lastname = this.route.snapshot.paramMap.get('lastname');
  //   console.log(lastname);
  //   console.log(this.updateMode);
  //   if (lastname == null)
  //     this.updateMode = true
  //   if (lastname == '') {
  //     this.updateMode = false;
  //   } else {
  //     this.contactService.getContactByLastname(lastname).subscribe(contact => {
  //     this.contact = contact;
  //     console.log(this.contact);
  //     this.setContactValue();
  //   });
  //   }
  // }

  setContactValue() {
    this.registerForm.patchValue({
        lastname: this.contact.lastName,
        firstname: this.contact.firstName,
        phone: this.contact.phone,
        email: this.contact.email,
        tc: true
      });
  }

  updateContact(id : number) {
    this.contactService.updateContact(id, this.registerForm.value).subscribe(() => {
      console.log("Contact Updated");
      this.cancel();
    }, err => console.log(err));
  }

  addContact() {
    this.contactService.registerContact(this.registerForm.value).subscribe(contact => {
      console.log("New Contact Added");
      this.cancel();
    });
  }

  cancel() {
    this.router.navigateByUrl('/contactTable');
  }
}
