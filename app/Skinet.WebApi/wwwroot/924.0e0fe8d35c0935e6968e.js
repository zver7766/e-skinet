(self.webpackChunkclient=self.webpackChunkclient||[]).push([[924],{8924:(e,t,r)=>{"use strict";r.r(t),r.d(t,{CheckoutModule:()=>C});var o=r(8583),s=r(15),n=r(665),c=r(3018),i=r(4878),a=r(9508),l=r(9630);function u(e,t){if(1&e){const e=c.EpF();c.TgZ(0,"li",4),c.TgZ(1,"button",5),c.NdJ("click",function(){c.CHM(e);const r=t.index;return c.oxw().onClick(r)}),c._uU(2),c.qZA(),c.qZA()}if(2&e){const e=t.$implicit,r=t.index,o=c.oxw();c.xp6(1),c.ekj("active",o.selectedIndex===r),c.xp6(1),c.AsE(" ",e.label,":",e.completed," ")}}let p=(()=>{class e extends l.B8{ngOnInit(){this.linear=this.linearModeSelected}onClick(e){this.selectedIndex=e}}return e.\u0275fac=function(t){return d(t||e)},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-stepper"]],inputs:{linearModeSelected:"linearModeSelected"},features:[c._Bn([{provide:l.B8,useExisting:e}]),c.qOj],decls:5,vars:2,consts:[[1,"container"],[1,"nav","nav-pills","nav-justified"],["class","nav-item",4,"ngFor","ngForOf"],[3,"ngTemplateOutlet"],[1,"nav-item"],[1,"nav-link","text-uppercase","font-weight-bold","btn-block",2,"padding","1.20em",3,"click"]],template:function(e,t){1&e&&(c.TgZ(0,"div",0),c.TgZ(1,"ul",1),c.YNc(2,u,3,4,"li",2),c.qZA(),c.TgZ(3,"div"),c.GkF(4,3),c.qZA(),c.qZA()),2&e&&(c.xp6(2),c.Q6J("ngForOf",t.steps),c.xp6(2),c.Q6J("ngTemplateOutlet",t.selected.content))},directives:[o.sg,o.tP],styles:["button.nav-link[_ngcontent-%COMP%]{background:#e9ecef;border-radius:0;border:none}button.nav-link[_ngcontent-%COMP%]:focus{outline:none}button.nav-link.active[_ngcontent-%COMP%]:hover{color:#fff}button.nav-link.active[_ngcontent-%COMP%]:focus, button.nav-link[_ngcontent-%COMP%]   [_ngcontent-%COMP%]:active{outline:none}"]}),e})();const d=c.n5z(p);var m=r(9344),g=r(4015);let h=(()=>{class e{constructor(e,t){this.accountService=e,this.toastr=t}ngOnInit(){}saveUserAddress(){this.accountService.updateUserAddress(this.checkoutForm.get("addressForm").value).subscribe(()=>{this.toastr.success("Address saved")},e=>{this.toastr.error(e.message),console.log(e)})}}return e.\u0275fac=function(t){return new(t||e)(c.Y36(i.B),c.Y36(m._W))},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-checkout-address"]],inputs:{checkoutForm:"checkoutForm"},decls:26,vars:8,consts:[[1,"mt-4",3,"formGroup"],[1,"d-flex","justify-content-between","align-items-center"],[1,"btn","btn-outline-success","mb-3",3,"disabled","click"],["formGroupName","addressForm",1,"row"],[1,"form-group","col-6"],["formControlName","firstName",3,"label"],["formControlName","lastName",3,"label"],["formControlName","street",3,"label"],["formControlName","city",3,"label"],["formControlName","state",3,"label"],["formControlName","zipCode",3,"label"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["routerLink","/basket",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],["cdkStepperNext","",1,"btn","btn-primary"],[1,"fa","fa-angle-right"]],template:function(e,t){1&e&&(c.TgZ(0,"div",0),c.TgZ(1,"div",1),c.TgZ(2,"h4"),c._uU(3,"Shipping address"),c.qZA(),c.TgZ(4,"button",2),c.NdJ("click",function(){return t.saveUserAddress()}),c._uU(5," Save as default address "),c.qZA(),c.qZA(),c.TgZ(6,"div",3),c.TgZ(7,"div",4),c._UZ(8,"app-text-input",5),c.qZA(),c.TgZ(9,"div",4),c._UZ(10,"app-text-input",6),c.qZA(),c.TgZ(11,"div",4),c._UZ(12,"app-text-input",7),c.qZA(),c.TgZ(13,"div",4),c._UZ(14,"app-text-input",8),c.qZA(),c.TgZ(15,"div",4),c._UZ(16,"app-text-input",9),c.qZA(),c.TgZ(17,"div",4),c._UZ(18,"app-text-input",10),c.qZA(),c.qZA(),c.qZA(),c.TgZ(19,"div",11),c.TgZ(20,"button",12),c._UZ(21,"i",13),c._uU(22," Back to basket "),c.qZA(),c.TgZ(23,"button",14),c._uU(24," Go to delivery "),c._UZ(25,"i",15),c.qZA(),c.qZA()),2&e&&(c.Q6J("formGroup",t.checkoutForm),c.xp6(4),c.Q6J("disabled",!t.checkoutForm.get("addressForm").valid||!t.checkoutForm.get("addressForm").dirty),c.xp6(4),c.Q6J("label","First name"),c.xp6(2),c.Q6J("label","Last name"),c.xp6(2),c.Q6J("label","Street"),c.xp6(2),c.Q6J("label","City"),c.xp6(2),c.Q6J("label","State"),c.xp6(2),c.Q6J("label","Zip code"))},directives:[n.JL,n.sg,n.x0,g.t,n.JJ,n.u,s.rH,l.st],styles:[""]}),e})();var b=r(8002),f=r(2340),Z=r(1841);let v=(()=>{class e{constructor(e){this.http=e,this.baseUrl=f.N.apiUrl}createOrder(e){return this.http.post(this.baseUrl+"orders",e)}getDeliveryMethods(){return this.http.get(this.baseUrl+"orders/deliveryMethods").pipe((0,b.U)(e=>e.sort((e,t)=>t.price-e.price)))}}return e.\u0275fac=function(t){return new(t||e)(c.LFG(Z.eN))},e.\u0275prov=c.Yz7({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();function k(e,t){if(1&e){const e=c.EpF();c.TgZ(0,"div",9),c.TgZ(1,"input",10),c.NdJ("click",function(){c.CHM(e);const r=t.$implicit;return c.oxw().setShippingPrice(r)}),c.qZA(),c.TgZ(2,"label",11),c.TgZ(3,"strong"),c._uU(4),c.ALo(5,"currency"),c.qZA(),c._UZ(6,"br"),c.TgZ(7,"span",12),c._uU(8),c.qZA(),c.qZA(),c.qZA()}if(2&e){const e=t.$implicit;c.xp6(1),c.s9C("id",e.id),c.s9C("value",e.id),c.xp6(1),c.s9C("for",e.id),c.xp6(2),c.AsE("",e.shortName," - ",c.lcZ(5,6,e.price),""),c.xp6(4),c.Oqu(e.description)}}let y=(()=>{class e{constructor(e,t){this.checkoutService=e,this.basketService=t}ngOnInit(){this.checkoutService.getDeliveryMethods().subscribe(e=>{this.deliveryMethods=e},e=>{console.log(e)})}setShippingPrice(e){this.basketService.setShippingPrice(e)}}return e.\u0275fac=function(t){return new(t||e)(c.Y36(v),c.Y36(a.v))},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-checkout-delivery"]],inputs:{checkoutForm:"checkoutForm"},decls:12,vars:2,consts:[[1,"mt-4",3,"formGroup"],[1,"mb-3"],["formGroupName","deliveryForm",1,"row"],["class","col-6 form-group",4,"ngFor","ngForOf"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["cdkStepperPrevious","",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],["cdkStepperNext","",1,"btn","btn-primary"],[1,"fa","fa-angle-right"],[1,"col-6","form-group"],["type","radio","formControlName","deliveryMethod",1,"custom-control-input",3,"id","value","click"],[1,"custom-control-label",3,"for"],[1,"label-description"]],template:function(e,t){1&e&&(c.TgZ(0,"div",0),c.TgZ(1,"h4",1),c._uU(2,"Choose your delivery method"),c.qZA(),c.TgZ(3,"div",2),c.YNc(4,k,9,8,"div",3),c.qZA(),c.qZA(),c.TgZ(5,"div",4),c.TgZ(6,"button",5),c._UZ(7,"i",6),c._uU(8," Back to address "),c.qZA(),c.TgZ(9,"button",7),c._uU(10," Go to review "),c._UZ(11,"i",8),c.qZA(),c.qZA()),2&e&&(c.Q6J("formGroup",t.checkoutForm),c.xp6(4),c.Q6J("ngForOf",t.deliveryMethods))},directives:[n.JL,n.sg,n.x0,o.sg,l.po,l.st,n._,n.Fj,n.JJ,n.u],pipes:[o.H9],styles:[""]}),e})();var A=r(3449);let x=(()=>{class e{constructor(e){this.basketService=e}ngOnInit(){this.basket$=this.basketService.basket$}}return e.\u0275fac=function(t){return new(t||e)(c.Y36(a.v))},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-checkout-review"]],decls:10,vars:4,consts:[[1,"mt-4"],[3,"isBasket","items"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["cdkStepperPrevious","",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],["cdkStepperNext","",1,"btn","btn-primary"],[1,"fa","fa-angle-right"]],template:function(e,t){1&e&&(c.TgZ(0,"div",0),c._UZ(1,"app-basket-summary",1),c.ALo(2,"async"),c.qZA(),c.TgZ(3,"div",2),c.TgZ(4,"button",3),c._UZ(5,"i",4),c._uU(6," Back to Delivery "),c.qZA(),c.TgZ(7,"button",5),c._uU(8," Go to Payment "),c._UZ(9,"i",6),c.qZA(),c.qZA()),2&e&&(c.xp6(1),c.Q6J("isBasket",!1)("items",c.lcZ(2,2,t.basket$).items))},directives:[A.b,l.po,l.st],pipes:[o.Ov],styles:[""]}),e})(),T=(()=>{class e{constructor(e,t,r,o){this.basketService=e,this.checkoutService=t,this.toastr=r,this.router=o}ngOnInit(){}submitOrder(){const e=this.basketService.getCurrentBasketValue(),t=this.getOrderToCreate(e);this.checkoutService.createOrder(t).subscribe(t=>{this.toastr.success("Order created successfully"),this.basketService.deleteLocalBasket(e.id),this.router.navigate(["checkout/success"],{state:t})},e=>{this.toastr.error(e.message),console.log(e)})}getOrderToCreate(e){return{basketId:e.id,deliveryMethodId:+this.checkoutForm.get("deliveryForm").get("deliveryMethod").value,shipToAddress:this.checkoutForm.get("addressForm").value}}}return e.\u0275fac=function(t){return new(t||e)(c.Y36(a.v),c.Y36(v),c.Y36(m._W),c.Y36(s.F0))},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-checkout-payment"]],inputs:{checkoutForm:"checkoutForm"},decls:9,vars:0,consts:[[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["cdkStepperPrevious","",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],[1,"btn","btn-primary",3,"click"],[1,"fa","fa-angle-right"]],template:function(e,t){1&e&&(c.TgZ(0,"p"),c._uU(1,"checkout-payment works!"),c.qZA(),c.TgZ(2,"div",0),c.TgZ(3,"button",1),c._UZ(4,"i",2),c._uU(5," Back to Review "),c.qZA(),c.TgZ(6,"button",3),c.NdJ("click",function(){return t.submitOrder()}),c._uU(7," Submit order "),c._UZ(8,"i",4),c.qZA(),c.qZA())},directives:[l.po],styles:[""]}),e})();var q=r(9281);function F(e,t){if(1&e&&(c._UZ(0,"app-order-totals",10),c.ALo(1,"async"),c.ALo(2,"async"),c.ALo(3,"async")),2&e){const e=c.oxw();c.Q6J("shippingPrice",c.lcZ(1,3,e.basketTotals$).shipping)("subtotal",c.lcZ(2,5,e.basketTotals$).subtotal)("total",c.lcZ(3,7,e.basketTotals$).total)}}function _(e,t){if(1&e&&(c.TgZ(0,"button",5),c._uU(1,"View your order"),c.qZA()),2&e){const e=c.oxw();c.MGl("routerLink","/orders/",null==e.order?null:e.order.id,"")}}function U(e,t){1&e&&(c.TgZ(0,"button",6),c._uU(1,"View your orders"),c.qZA())}const S=[{path:"",component:(()=>{class e{constructor(e,t,r){this.fb=e,this.accountService=t,this.basketService=r}ngOnInit(){this.createCheckoutForm(),this.getAddressFormValues(),this.basketTotals$=this.basketService.basketTotal$}createCheckoutForm(){this.checkoutForm=this.fb.group({addressForm:this.fb.group({firstName:[null,n.kI.required],lastName:[null,n.kI.required],street:[null,n.kI.required],city:[null,n.kI.required],state:[null,n.kI.required],zipCode:[null,n.kI.required]}),deliveryForm:this.fb.group({deliveryMethod:[null,n.kI.required]}),paymentForm:this.fb.group({nameOnCard:[null,n.kI.required]})})}getAddressFormValues(){this.accountService.getUserAddress().subscribe(e=>{e&&this.checkoutForm.get("addressForm").patchValue(e)},e=>{console.log(e)})}}return e.\u0275fac=function(t){return new(t||e)(c.Y36(n.qu),c.Y36(i.B),c.Y36(a.v))},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-checkout"]],decls:16,vars:13,consts:[[1,"container","mt-5"],[1,"row"],[1,"col-8"],[3,"linearModeSelected"],["appStepper",""],[3,"label","completed"],[3,"checkoutForm"],[3,"label"],[1,"col-4"],[3,"shippingPrice","subtotal","total",4,"ngIf"],[3,"shippingPrice","subtotal","total"]],template:function(e,t){1&e&&(c.TgZ(0,"div",0),c.TgZ(1,"div",1),c.TgZ(2,"div",2),c.TgZ(3,"app-stepper",3,4),c.TgZ(5,"cdk-step",5),c._UZ(6,"app-checkout-address",6),c.qZA(),c.TgZ(7,"cdk-step",5),c._UZ(8,"app-checkout-delivery",6),c.qZA(),c.TgZ(9,"cdk-step",7),c._UZ(10,"app-checkout-review"),c.qZA(),c.TgZ(11,"cdk-step",7),c._UZ(12,"app-checkout-payment",6),c.qZA(),c.qZA(),c.qZA(),c.TgZ(13,"div",8),c.YNc(14,F,4,9,"app-order-totals",9),c.ALo(15,"async"),c.qZA(),c.qZA(),c.qZA()),2&e&&(c.xp6(3),c.Q6J("linearModeSelected",!1),c.xp6(2),c.Q6J("label","Address")("completed",t.checkoutForm.get("addressForm").valid),c.xp6(1),c.Q6J("checkoutForm",t.checkoutForm),c.xp6(1),c.Q6J("label","Delivery")("completed",t.checkoutForm.get("deliveryForm").valid),c.xp6(1),c.Q6J("checkoutForm",t.checkoutForm),c.xp6(1),c.Q6J("label","Review"),c.xp6(2),c.Q6J("label","Payment"),c.xp6(1),c.Q6J("checkoutForm",t.checkoutForm),c.xp6(2),c.Q6J("ngIf",c.lcZ(15,11,t.basketTotals$)))},directives:[p,l.be,h,y,x,T,o.O5,q.S],pipes:[o.Ov],styles:[""]}),e})()},{path:"success",component:(()=>{class e{constructor(e){this.router=e;const t=this.router.getCurrentNavigation(),r=t&&t.extras&&t.extras.state;r&&(this.order=r)}ngOnInit(){}}return e.\u0275fac=function(t){return new(t||e)(c.Y36(s.F0))},e.\u0275cmp=c.Xpm({type:e,selectors:[["app-checkout-success"]],decls:9,vars:2,consts:[[1,"container","mt-5"],[1,"fa","fa-check-circle","fa-5x",2,"color","green"],[1,"mb-4"],["class","btn btn-outline-success",3,"routerLink",4,"ngIf"],["routerLink","/orders","class","btn btn-outline-success",4,"ngIf"],[1,"btn","btn-outline-success",3,"routerLink"],["routerLink","/orders",1,"btn","btn-outline-success"]],template:function(e,t){1&e&&(c.TgZ(0,"div",0),c.TgZ(1,"div"),c._UZ(2,"i",1),c.qZA(),c.TgZ(3,"h2"),c._uU(4,"Thank you. Your order is confirmed"),c.qZA(),c.TgZ(5,"p",2),c._uU(6,"Your order has not shipped yet, but this is to be expected as we are not a real store"),c.qZA(),c.YNc(7,_,2,1,"button",3),c.YNc(8,U,2,0,"button",4),c.qZA()),2&e&&(c.xp6(7),c.Q6J("ngIf",t.order),c.xp6(1),c.Q6J("ngIf",!t.order))},directives:[o.O5,s.rH],styles:[""]}),e})()}];let w=(()=>{class e{}return e.\u0275mod=c.oAB({type:e}),e.\u0275inj=c.cJS({factory:function(t){return new(t||e)},imports:[[s.Bz.forChild(S)],s.Bz]}),e})();var J=r(4466);let C=(()=>{class e{}return e.\u0275mod=c.oAB({type:e}),e.\u0275inj=c.cJS({factory:function(t){return new(t||e)},imports:[[o.ez,w,J.m]]}),e})()}}]);