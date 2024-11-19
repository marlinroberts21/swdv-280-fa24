﻿namespace total_test_1.Models.Admin
{
	public class FullDisplay
	{
		public DateOnly Date { get; set; }
		public TimeOnly Time { get; set; }


		public string FirstName { get; set; }
		public string LastName { get; set; }


		public string Category { get; set; }


		public string Email { get; set; }
		public int Phone { get; set; }

        public FullDisplay(DateOnly date, TimeOnly time, string firstName, string lastName, string category, string email, int phone)
        {
			Date = date;
			Time = time;

			FirstName = firstName;
			LastName = lastName;

			Category = category;

			Email = email;
			Phone = phone;
        }
    }
}