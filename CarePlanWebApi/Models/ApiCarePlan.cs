using System;
using System.Text.Json.Serialization;

namespace CarePlanWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiCarePlan
    {
        /// <summary>
        /// Gets or sets the care plan identifier. [Required]
        /// </summary>
        /// <value>
        /// The care plan identifier.
        /// </value>
        [JsonPropertyName("id")] 
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title. [Required, Max: 450 chars]
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the patient. [Required, Max: 450 chars]
        /// </summary>
        /// <value>
        /// The name of the patient.
        /// </value>
        [JsonPropertyName("patient_name")]
        public string PatientName { get; set; }

        /// <summary>
        /// Gets or sets the name of the user. [Required, Max: 450 chars]
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the actual start date. [Required]
        /// </summary>
        /// <value>
        /// The actual start date.
        /// </value>
        [JsonPropertyName("actual_start_date")]
        public DateTime ActualStartDate { get; set; }

        /// <summary>
        /// Gets or sets the target date. [Required]
        /// </summary>
        /// <value>
        /// The target date.
        /// </value>
        [JsonPropertyName("target_date")]
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// Gets or sets the reason. [Required, Max: 1000 chars]
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the action. [Required, Max: 1000 chars]
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the completed.
        /// </summary>
        /// <value>
        /// The completed.
        /// </value>
        [JsonPropertyName("completed")]
        public bool? Completed { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the outcome. [Max: 1000 chars]
        /// </summary>
        /// <value>
        /// The outcome.
        /// </value>
        [JsonPropertyName("outcome")]
        public string Outcome { get; set; }
    }
}
