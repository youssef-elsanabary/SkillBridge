import { Contract } from "./contract";
import { User } from "./user";

export class Service {
    constructor(
        public userId : number,
        public title : string,
        public description : string,
        public price : number,
        public category : string,
        public status : string,
        public createdDate : Date,
        public serviceId? : number,
        public user? : User,
        public contract? :Contract
    // "serviceId": 0,
    // "userId": 0,
    // "title": "string",
    // "description": "string",
    // "price": 0,
    // "category": "string",
    // "status": "string",
    // "createdDate": "2024-10-15T15:44:56.219Z",
    ){}
}
