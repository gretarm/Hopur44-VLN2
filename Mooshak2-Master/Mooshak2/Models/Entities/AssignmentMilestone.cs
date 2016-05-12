using System.Collections.Generic;

namespace Mooshak2.Models.Entities
{
	/// <summary>
	/// AssignmentMilestone represents a part of an assigment
	/// Each assignment may contain many milestones which
	/// themselves represent a percentage of the final grade
	/// </summary>
	public class AssignmentMilestone
	{
		/// <summary>
		/// The database-generated unique ID of the milestone.
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// A foreign key to the assignment.
		/// </summary>
		public int AssignmentID { get; set; }

		/// <summary>
		/// Title of milestone: For example "Part 1"
		/// </summary>
		public string Title { get; set; }
  
		/// <summary>
		/// Determines how much this milestone weighs in the assignment
		/// For example: If this milestone weighs 15% then this property contains the value of 15
		/// </summary>
		public int Weight { get; set; }

        /// <summary>
        /// The best submission this particular Milestone had from the user
        /// </summary>
        public string BestSubmission { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}