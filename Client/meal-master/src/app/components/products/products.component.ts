// src/app/components/products/products.component.ts
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ProductResponseDto } from '../../models/product-response.dto';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  standalone: true
})
export class ProductsComponent implements OnInit {
  products: ProductResponseDto[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getAll().subscribe((data) => {
      this.products = data;
    });
  }
}
