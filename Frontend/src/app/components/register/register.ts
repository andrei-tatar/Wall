import {Component} from '../../util';
//import './login.css!';

@Component('wallRegister', {
    templateUrl: 'app/components/register/register.html'
})
class WallRegister implements ng.IComponentController {
    public user: string;
    public password: string;
    public confirm_password: string;
    public userType: string;
    
    
    public checkPassword() {
   
   
          if ( this.password != this.confirm_password) {

            console.log("They Do not match");
            return false;
         
          }    else {

              console.log("They match");
              return true;
          }
    }
 
}