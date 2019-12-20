import { Component } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'pdfdownloadclient';
  constructor(private http: HttpClient) {}
  isLoading:boolean;
  openPDF(){
    console.log("PDF open");
    this.isLoading=true;
    this.downloadPDF()
      .subscribe(
        filedata => {
          this.isLoading=false;
          var windo = window.open("", "");
          var objbuilder = '';
          objbuilder += ('<embed width=\'100%\' height=\'100%\'  src="data:application/pdf;base64,');
          objbuilder += (filedata);
          objbuilder += ('" type="application/pdf" />');
          windo.document.write(objbuilder);
        }
      )
  }

  Test(openPDF){

  }

  downloadPDF() {
    let headers: HttpHeaders = new HttpHeaders();
    headers = headers.append('Accept', 'application/json');
    return this.http
      .get("http://localhost:5000/api/pdf/getpdf",{headers:headers});
  }
}
