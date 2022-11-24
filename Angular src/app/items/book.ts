export class Book {

    title!: string
    author!: string
    genre!: string
    price!: number
    available!: number


    constructor(title: string, author: string, genre: string, price: number){
        this.title=title;
        this.author=author;
        this.genre=genre;
        this.price=price;
    }

}