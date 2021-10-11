export class LoggedInUser {

    constructor(id: string, fname: string, lname: string, username: string, role: string){
            this.id = id;
            this.firstName = fname;
            this.lastName = lname;
            this.username = username;
            this.password = username;
            this.adminId = role;
        }
        public id: string;
        public firstName: string;
        public lastName: string;
        public username: any;
        public password: string;
        public adminId: string;
}
