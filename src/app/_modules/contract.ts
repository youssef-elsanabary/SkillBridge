export class Contract {
    constructor(
        public serviceId : number,
        public userId : number,
        public status : string,
        public price : number,
        public duration : number,
        public createdDate? : Date,
        public contractId? : number
    ){}
}
