

export class Laptop {
    
    brand!: string
    model!: string
    ram!: number
    price!: number



    constructor(brand: string, model: string, ram: number, price: number){
        this.brand=brand;
        this.model=model;
        this.ram=ram;
        this.price=price;
    }
}