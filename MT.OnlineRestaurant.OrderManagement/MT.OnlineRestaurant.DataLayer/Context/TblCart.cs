using System;
using System.Collections.Generic;

namespace MT.OnlineRestaurant.DataLayer.Context
{
    public partial class TblCart
    {
        public TblCart()
        {
            TblCartDetails = new HashSet<TblCartDetail>();

        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<TblCartDetail> TblCartDetails { get; set; }
    }
}
