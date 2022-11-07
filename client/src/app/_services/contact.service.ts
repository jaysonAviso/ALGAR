import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from '../_models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  baseUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  getContacts() {
    return this.http.get<Contact[]>(this.baseUrl + 'contact');
  }

  getContactById(id: number){
    return this.http.get<Contact>(this.baseUrl + 'contact/' + id);
  }

  getContactByLastname(lastname: string) {
    return this.http.get<Contact[]>(this.baseUrl + 'contact/lastname/' + lastname); 
  }

  registerContact(contact: any){
    return this.http.post<Contact>(this.baseUrl + 'contact', contact);
  }

  updateContact(id: number, contact: Contact) {
    return this.http.put<Contact>(this.baseUrl + 'contact/' + id, contact);
  }

  deleteContact(id: number) {
    return this.http.delete(this.baseUrl + 'contact/' + id);
  }

}
