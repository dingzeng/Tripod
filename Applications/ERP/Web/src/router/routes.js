import Main from '../views/main'

export default [
    { path: '/login', name: 'login', component: () => import("../views/login") },
    { 
        path: '/', 
        name: 'main', 
        component: Main, 
        children:  [
            { path: '/archive/itemcls', name: 'archive_itemcls', component: () => import("../views/archive/itemcls-list") },
            { path: '/archive/item', name: 'archive_item', component: () => import("../views/archive/item-list") },
        ]
    }
]