export interface Product {
    image: string,
    uname: string,
    gmail: string,
    productName: string,
    status: string,
    weeks: number,
    budget: string
}

export const TopSelling: Product[] = [

    {
        image: 'assets/images/users/user1.jpg',
        uname: 'Chai',
        gmail: '',
        productName: 'All Seasons',
        status: 'danger',
        weeks: 35,
        budget: '95K'
    },
    {
        image: 'assets/images/users/user2.jpg',
        uname: 'Tofu',
        gmail: '',
        productName: 'Seasonal',
        status: 'info',
        weeks: 35,
        budget: '80K'
    },
    {
        image: 'assets/images/users/user3.jpg',
        uname: 'Chocolade',
        gmail: '',
        productName: 'All easons	',
        status: 'warning',
        weeks: 35,
        budget: '95K'
    },
    {
        image: 'assets/images/users/user4.jpg',
        uname: 'Ipoh Coffee',
        gmail: '',
        productName: 'Seasonal',
        status: 'success',
        weeks: 35,
        budget: '85K'
    },

]