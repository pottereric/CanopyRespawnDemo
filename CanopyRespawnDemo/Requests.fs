module Requests

open canopy

let ClickCreateNew _ = 
    click "Create New"

let SetEndDate endDate =
    "#dp_endDate" << endDate

let SetLocation location = 
    "#Location" << location

let SetDescription description =
    "#Description" << description

let ClickCreate _ =
    click "Create"

let CreateNewRequest endDate location description =
    ClickCreateNew()
    SetEndDate endDate
    press tab
    SetLocation location
    sleep 1
    SetDescription description
    sleep 1
    ClickCreate()

let AssertDescriptionExists description =
    "td" *= description