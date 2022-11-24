


export class BookWishList{
    
    userId!:string
    lowPrice=0;
    highPrice=2147483647;
    title!:string
    author!:string
    genre!:string

    constructor(userId:string, lowPrice:number, highPrice:number, title:string, author:string, genre:string){
        this.userId=userId;
        this.lowPrice=lowPrice;
        this.highPrice=highPrice;
        this.title=title;
        this.author=author;
        this.genre=genre;
    }

}