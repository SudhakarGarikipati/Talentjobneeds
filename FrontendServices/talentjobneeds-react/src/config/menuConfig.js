
// Defines which menu items each role should see.
const menu = () => {
admin:[
    { label:"Dashboard", path:"/admin/home"},
    {label:"Users", path:"/admin/users"},
    {label:"Settings", path:"/admin/settings"}
]
jobseeker:[
    {label:"Home", path:"/jobseeker/home"},
    {label:"Searh Jobs ", path:"/jobseeker/search"},
    {label:"Preferences", path:"/jobseeker/Preferences"}
]
employer:[
    {label:"Home", path:"/employer/home"},
    {label:"Post Jobs", path:"/employer/postjob"},
    {label:"Applicants", path:"/employer/applicants"}
]
}
export default menu;