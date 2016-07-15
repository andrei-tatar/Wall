import { Controller } from './util'

@Controller('mainController', '$http', 'apiUri')
class MainController implements angular.IComponentController {
    public result : { name? : string; description? : string} = {};
    public loading : boolean = true;

    constructor(http: angular.IHttpService, apiUri: string) {
        http.get(apiUri + 'api/test')
            .then(response => {
                this.result = response.data;
                this.loading = false;
            })
            .catch(error => {
                alert("There was an error handling the request to the service!");
            });
    }

    public $onInit() {
        console.log("init!");
    }
}