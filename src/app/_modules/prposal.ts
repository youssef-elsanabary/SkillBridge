import { User } from "./user";

export class Prposal {
    constructor(
        public serviceId : number,
        public userId : number,
        public proposalDate : Date,
        public status : string,
        public proposalId? : number,
        public user? :User
    ){}
}