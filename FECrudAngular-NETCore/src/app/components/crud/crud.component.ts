import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from 'src/app/services/contact.service';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css']
})
export class CRUDComponent implements OnInit {

  currentLanguage = 'es'; // Idioma por defecto.
  translations: { [key: string]: string } = {}; // Aquí se almacenarán las traducciones.

  form:FormGroup;
  fileError = false;

  constructor(private fb: FormBuilder, 
              private ContactService: ContactService,
              private LanguageService: LanguageService) {
    this.form = this.fb.group({
      apellido:['', [Validators.required, Validators.pattern(/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/)]],
      nombre: ['', [Validators.required, Validators.pattern(/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/)]],
      correo:['', [Validators.required, Validators.email]],
      comentario:['', [Validators.required, Validators.pattern(/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/)]],
      pdfAdjunto: [null]
    })
   }

   onFileSelect(event: Event): void {
    const file = (event.target as HTMLInputElement).files![0];
    if (file && (file.type === 'application/pdf' || file.type.startsWith('image/'))) {
      this.fileError = false;
      this.form.patchValue({ attachment: file });
    } else {
      this.fileError = true;
    }
  }

  SaveData() {
    const contact : any = {
      apellido: this.form.get('apellido')?.value,
      nombre: this.form.get('nombre')?.value,
      correo: this.form.get('correo')?.value,
      comentario: this.form.get('comentario')?.value,
      pdfAdjunto: this.form.get('pdfAdjunto')?.value,
    }
    if (this.form.invalid) {
      this.markTouchedFields(this.form);
      return;
    }
    // Mostrar un mensaje de confirmación
    const confirmSave = confirm("¿Está seguro de que desea guardar este formulario?");
    if (!confirmSave) {
        return; // Salir si el usuario cancela la acción
    }

    // Aquí procesas los datos del formulario
    this.ContactService.GuardarContacto(contact).subscribe(data => {
      alert("Formulario guardado con éxito.");
      this.form.reset();
    },
    error => {
        alert("Ocurrió un error al guardar el formulario."); // Mensaje de error
    });
    //console.log(this.form.value); 
  }
  
  private markTouchedFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(control => {
      const controlObj = formGroup.get(control);
      if (controlObj instanceof FormGroup) {
        this.markTouchedFields(controlObj);
      } else {
        controlObj?.markAsTouched();
      }
    });
  }

  ngOnInit(): void {
    this.loadTranslations(this.currentLanguage);
  }

  // Funcion de cambio de idioma del formulario
  onLanguageChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    this.currentLanguage = selectElement.value;
    this.loadTranslations(this.currentLanguage);
  }

  // carga del idioma de traduccion
  private loadTranslations(language: string): void {
    this.LanguageService.getLanguageLabels(language).subscribe({
      next: (response: any) => {
        this.translations = this.formatTranslations(response);
      },
      error: (error) => {
        console.error('Error al cargar las traducciones:', error);
      },
    });
  }

  // Selecciona el formato de traduccion
  private formatTranslations(data: any): { [key: string]: string } {
    const formatted: { [key: string]: string } = {};
    data.forEach((item: any) => {
      formatted[item.clave] = item.texto;
    });
    return formatted;
  }

}
