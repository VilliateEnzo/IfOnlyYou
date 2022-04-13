import { Component, Input, OnInit } from '@angular/core';
import { Photo } from 'src/app/_models/photo';

@Component({
  selector: 'app-member-gallery',
  templateUrl: './member-gallery.component.html',
  styleUrls: ['./member-gallery.component.css']
})
export class MemberGalleryComponent implements OnInit {
  @Input() fotos: Photo[];
  fotoActual: Photo;
  constructor() { }

  ngOnInit(): void {
  }

  setImg(foto: Photo) {
    this.fotoActual = foto;
  }

}
