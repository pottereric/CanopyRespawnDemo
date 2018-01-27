module Login

open canopy

let Login userName password =
    url "http://localhost:2077/Account/Login"
    "#UserNameOrEmail" << userName
    "#Password" << password
    click "Log in"

let LoginAdministrator _ =
    Login Constants.AdministratorUserName Constants.AdministratorPassword
   
let LoginTestUser _ =
    Login Constants.TestUserUserName Constants.TestUserPassword


